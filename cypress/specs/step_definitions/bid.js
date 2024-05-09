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

When('I click on the Lägg ditt bud button', () => {
  cy.get('input').click();
});

Then('a {string} message should show', (message) => {
  cy.get('.page-container').should('contain', message);
});