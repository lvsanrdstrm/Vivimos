import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

/* No duplicate steps, this one already in individual.js
Given('I am on the {string} page', (a) => {});*/

/* No duplicate steps, this one already in login.js
Given('I click on the {string} button', (a) => {});*/

Given('a register modal pops up', () => {
  // TODO: implement step
});

Given('I type in my user data', () => {
  cy.get('.modal-body').within(() => {
    cy.get('[type="text"]').type('blob');
    cy.get('[type="email"]').type('blob@blob.yes');
    cy.get('[type="password"]').type('blob');
  });
});

/* No duplicate steps, this one already in login.js
Given('I click on the {string} button', (a) => {});*/

/* No duplicate steps, this one already in login.js
Then('I should see a {string} title', (a) => {});*/