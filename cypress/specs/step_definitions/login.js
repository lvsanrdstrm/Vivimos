import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";


When('I click on the "Logga in" button', () => {
  // Click on the "Logga in" button
  cy.get('.loginButton').click();
});


Given('a login modal pops up', () => {
  cy.get('.modal-body').should('be.visible');
});


Given('I type in my username and password', () => {
  // Type username and password within the modal
  cy.get('.modal-body').within(() => {
    cy.get('form > [type="text"]').type('rosa.parks');
    cy.get('[type="password"]').type('bus');
  });
});
;


Given('I click on the "Login" button', () => {
  // Click on the "Login" button within the modal
  cy.get('.modal-body').within(() => {
    cy.get('form > button').click();
  });
});


Then('I should see a {string} title', (title) => {
  cy.get('[href="/users/:id"]').should('have.text', title)
});
