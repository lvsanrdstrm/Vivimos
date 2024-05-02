import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

let adTitleText;

When('I click on an ad title', () => {
  // Get the text of the ad title before clicking on it
  cy.get(':nth-child(2) > .ad-info > .ad-title > a').invoke('text').then(text => {
    adTitleText = text.trim(); // Save the text of the ad title
  });

  // Click on the ad title
  cy.get(':nth-child(2) > .ad-info > .ad-title > a').click();
});

Then('I should be on an individual ad site', () => {
  // Assert that the title of the individual ad site matches the text of the clicked ad title
  cy.get('h1').should('have.text', adTitleText);
});
