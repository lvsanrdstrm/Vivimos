import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";


// Use the login step in your test
Given('I am logged in', () => {
  cy.login();
});

When('I click on the bidding button', () => {
  cy.get(':nth-child(2) > .ad-right > .button-container > button').click();
});

When('I get redirected to the {string} site', (expectedUrl) => {
  cy.url().should('include', expectedUrl);
});

When('I click on bid-placing button', () => {
  cy.get('input').click();
});

Then('a {string} alert should pop up', (a) => {
  // TODO: implement step
});
