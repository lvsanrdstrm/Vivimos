import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I am on the {string} page', (url) => {
  cy.visit(url, { headers: { "Accept-Encoding": "gzip, deflate" } })
});


Then('I should see {string} as the title', (title) => {
  cy.get('h1').should('have.text', title)
});