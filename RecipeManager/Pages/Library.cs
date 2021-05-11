﻿using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RecipeManager.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager.Pages
{
    public partial class Library
    {
        [Inject]
        private HttpClient Http { get; set; }
        private bool HideNewButton = false;
        private bool HideCreateUserForm = true;
        private bool HideDeleteCookbookForm = true;
        private List<CookbookDto> Cookbooks = new List<CookbookDto>();
        private CreateCookbookModel createCookbookModel = new CreateCookbookModel();
        private string TargetedCookbook = "";
        private Guid CookbookIdToBeDeleted = new Guid();
        private DeleteCookbookModel deleteCookbookModel = new DeleteCookbookModel();

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
            var postData = new StringContent(JsonConvert.SerializeObject(createCookbookModel), Encoding.UTF8, "application/json");
            var response = await Http.PostAsync(apiName, postData);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                CookbookDto user = JsonConvert.DeserializeObject<CookbookDto>(await response.Content.ReadAsStringAsync());
                if (user != null)
                    createCookbookModel = new CreateCookbookModel();
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
            deleteCookbookModel = new DeleteCookbookModel();
        }

        public async void DeleteCookbookButtonClicked(DeleteCookbookModel cookbook)
        {
            if (cookbook.Name == TargetedCookbook)
            {
                RestoreInitialState();
                cookbook.CookbookId = CookbookIdToBeDeleted;
                await DeleteCookbook(cookbook);
                return;
            }
        }

        private async Task DeleteCookbook(DeleteCookbookModel cookbook)
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
