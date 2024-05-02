import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

When('I search for {string}', (searchTerm) => {
  cy.get('input').type(searchTerm + '{enter}')
});

Then('I should see {string} in the search results', (searchTerm) => {
  cy.get(':nth-child(2) > .ad-info > :nth-child(2)').should('contain', searchTerm, { matchCase: false })
});