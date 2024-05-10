import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

When('I click on Skapa annons', () => {
  cy.get('[href="/' + "createAd" + '"]').click()
});


When('I mark {string}', (button) => {
  if (button === 'Publicera') { cy.buttonByIndex(2).type('Publicera').check(); } else if (button === 'Spara') { cy.buttonByIndex(3).type('Spara').check(); }
});

When('I choose an end date', () => {
  cy.get('[type="date"]').type('2025-01-08')
});