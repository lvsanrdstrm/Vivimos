import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";


When('I log in', () => {
  cy.get('.loginButton').click();
  cy.get('.modal-body').should('be.visible');
  cy.get('.modal-body').within(() => {
    cy.get('form > [type="text"]').type('rosa.parks');
    cy.get('[type="password"]').type('bus');
  });
  cy.get('.modal-body').within(() => {
    cy.get('form > button').click();
  });
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