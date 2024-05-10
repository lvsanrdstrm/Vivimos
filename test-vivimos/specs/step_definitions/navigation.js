import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";


When('I click on {string} in the menu', (pathName) => {
  cy.get('[href="/' + pathName + '"]').click()
});


Then('I should see the {string} page', (expectedUrl) => {
  cy.url().should('include', expectedUrl);
});