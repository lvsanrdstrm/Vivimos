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

When('I can see {string} heading', (expectedText) => {
  cy.get('h2').should('include.text', expectedText);
});

When('I click on bid-placing button', () => {
  cy.get('input').click();
});

Then('a {string} paragraph should be visible', (a) => {
  cy.get('#sparatBud').should('be.visible');
});