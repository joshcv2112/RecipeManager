using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RecipeManager.UI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.UI.Pages
{
    public partial class Library
    {
        [Inject]
        private HttpClient Http { get; set; }
        private bool HideNewButton = false;
        private bool HideCreateUserForm = true;
        private bool HideDeleteCookbookForm = true;
        private List<CookbookDto> Cookbooks = new List<CookbookDto>();
        private CookbookDto cookbookDto = new CookbookDto();
        private string TargetedCookbook = "";
        private Guid CookbookIdToBeDeleted = new Guid();

        #region StateManagement
        private void RestoreInitialState()
        {
            HideNewButton = false;
            HideCreateUserForm = true;
            HideDeleteCookbookForm = true;
        }

        private void AddNewButtonClicked()
        {
            HideNewButton = true;
            HideCreateUserForm = false;
            HideDeleteCookbookForm = true;
        }

        private void DeleteCookbookButtonClicked()
        {
            // TODO: When something is deleted it should also delete the image from blob storage.

            HideNewButton = true;
            HideCreateUserForm = true;
            HideDeleteCookbookForm = false;
        }
        #endregion

        #region OnPageLoad
        protected override async Task OnInitializedAsync()
        {
            await GetCookbooksForCurrentUser();
        }

        private async Task GetCookbooksForCurrentUser()
        {
            var apiName = "api/Cookbooks";
            var httpResponse = await Http.GetAsync(apiName);
            if (httpResponse.IsSuccessStatusCode)
            {
                List<CookbookDto> responseData = JsonConvert.DeserializeObject<List<CookbookDto>>(await httpResponse.Content.ReadAsStringAsync());
                Cookbooks = responseData;
                StateHasChanged();
            }
        }
        #endregion

        #region CreateCookbook
        private async Task CreateNewUser()
        {
            string apiName = "api/cookbooks";
            var postData = new StringContent(JsonConvert.SerializeObject(cookbookDto), Encoding.UTF8, "application/json");
            var response = await Http.PostAsync(apiName, postData);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                CookbookDto user = JsonConvert.DeserializeObject<CookbookDto>(await response.Content.ReadAsStringAsync());
                if (user != null)
                    cookbookDto = new CookbookDto();
            }
            RestoreInitialState();
            await OnInitializedAsync();
        }
        #endregion

        #region DeleteCookbook
        public void ShowHideDeleteCookbookDialog(CookbookDto cookbook)
        {
            CookbookIdToBeDeleted = cookbook.CookbookId;
            TargetedCookbook = cookbook.Name;
            DeleteCookbookButtonClicked();
        }

        public void HideDeleteCookbookDialog()
        {
            RestoreInitialState();
            cookbookDto = new CookbookDto();
        }

        public async void DeleteCookbookButtonClicked(CookbookDto cookbook)
        {
            if (cookbook.Name == TargetedCookbook)
            {
                RestoreInitialState();
                cookbook.CookbookId = CookbookIdToBeDeleted;
                await DeleteCookbook(cookbook);
                return;
            }
        }

        private async Task DeleteCookbook(CookbookDto cookbook)
        {
            string apiName = string.Format($"api/Cookbooks/{cookbook.CookbookId}");
            var response = await Http.DeleteAsync(apiName);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfully deleted cookbook: " + cookbook.Name + " (" + cookbook.CookbookId + ")");
                await OnInitializedAsync();
            }
            HideDeleteCookbookDialog();
        }
        #endregion
    }
}
