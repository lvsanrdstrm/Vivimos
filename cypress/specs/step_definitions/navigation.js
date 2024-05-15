import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('I am on the {string} page', (url) => {
  cy.visit(url)
});

When('I click on {string} in the menu', (phrase) => {
  cy.get('[href="/' + phrase + '"]').click()
})


Then('I should see {string} as the title', (title) => {
  cy.get('h1').should('have.text', title)
});