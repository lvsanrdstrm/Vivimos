import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I am on the {string} page', (url) => {
  cy.visit(url)
});

// kan man generalisera dessa och använda tsm? modalerna är generiska, har ej namn
// When('a login modal pops up', () => {
//   cy.get('.modal-body').should('be.visible');
// });

// When('a register modal pops up', () => {
//   // TODO: implement step
// });

When('a {string} modal pops up', () => {
  cy.get('.modal-body').should('be.visible');
});

When('I enter user credentials', () => {
  cy.get('.modal-body').within(() => {
    cy.get('form > [type="text"]').type('rosa.parks');
    cy.get('[type="password"]').type('bus');
  });
});


Then('I should seen the Min sida title', () => {
  cy.get('[href="/users/:id"]').should('have.text', "Min sida")
});


When('I click on {string} button', (buttonName) => {
  cy.contains('button', buttonName).click();

});




