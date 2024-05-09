import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

/* No duplicate steps, this one already in bid.js
Given('I am on the {string} page', (a) => {});*/

/* No duplicate steps, this one already in bid.js
When('I log in', () => {});*/

When('I click on the {string} nav title', (a) => {
  cy.get('[href="/createAd"]').click();
});

When('I am redirected to the {string} site', (expectedUrl) => {
  cy.url().should('include', expectedUrl);
});

When('I click on the continue button', (a) => {
  cy.get(':nth-child(26)')
});

When('I am redirected to the second page', () => {
  // TODO: implement step
});

/* No duplicate steps, this one already above
When('I click on the {string} button', (a) => {});*/

When('I am redirected to the third page', () => {
  // TODO: implement step
});

/* No duplicate steps, this one already above
When('I click on the {string} button', (a) => {});*/

When('I am redirected to the fourth page', () => {
  // TODO: implement step
});

/* No duplicate steps, this one already above
When('I click on the {string} button', (a) => {});*/

When('I am redirected to the fifth page', () => {
  // TODO: implement step
});

/* No duplicate steps, this one already above
When('I click on the {string} button', (a) => {});*/

When('I am redirected to the final page', () => {
  // TODO: implement step
});

When('I mark {string}', (a) => {
  // TODO: implement step
});

When('I click on {string}', (a) => {
  // TODO: implement step
});

Then('{string} should be displayed', (a) => {
  // TODO: implement step
});