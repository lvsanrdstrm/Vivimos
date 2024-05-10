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



