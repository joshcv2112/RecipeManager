import { Selector } from 'testcafe';

fixture `Getting Started`
    .page `https://localhost:5021/`;

test('My first test', async t => {
    const loginLink = await Selector('a').withText('Log in');
    const userNameTF = await Selector('#Input_UserName');
    const passwordTF = await Selector('#Input_Password');
    const loginBtn = await Selector('button').withText('Log in');
    const helloLink = await Selector('a').withText('Hello, joshcv2112!');

    await t.click(loginLink)
           .click(userNameTF)
           .typeText(userNameTF, 'joshcv2112')
           .typeText(passwordTF, 'WC@Rh0pe')
           .click(loginBtn)
           .expect(helloLink.textContent).contains('joshcv2112');
    
    const cookbooksBtn = await Selector('a').withText('Cookbooks');
    const addNewBtn = await Selector('button').withText('Add New');
    const nameTF = await Selector('#Name');
    const descriptionTF = await Selector('#Description');
    const createBtn = await Selector('button').withText('Create');


    await t.click(cookbooksBtn)
           .click(addNewBtn)
           .typeText(nameTF, 'New Test Cookbook')
           .typeText(descriptionTF, 'New test cookbook for testing')
           .click(createBtn);

    const cookbookTitle = await Selector('h3').withText('New Test Cookbook');

    await t.expect(cookbookTitle.textContent).contains('New Test Cookbook');
});