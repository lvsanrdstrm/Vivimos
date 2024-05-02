import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

/* No duplicate steps, this one already in navigation.js
Given('I am on the {string} page', (a) => {});*/

When('I search for {string}', (a) => {
  // TODO: implement step
});

Then('I should see {string} in the search results', (a) => {
  // TODO: implement step
});

/* No duplicate steps, this one already in navigation.js
Given('I am on the {string} page', (a) => {});*/

When('I search for {string}', (searchTerm) => {
  // TODO: implement step
});

Then('I should see {string} in the search results', (searchTerm) => {
  // TODO: implement step
});