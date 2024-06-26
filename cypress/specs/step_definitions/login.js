import { Given, When, Then } from "@badeball/cypress-cucumber-preprocessor";

Given('a modal pops up', () => {
  cy.get('.modal-body').should('be.visible');
});


When('I type in my user credentials', () => {
  cy.get('.modal-body').within(() => {
    cy.get('form > [type="text"]').type('rosa.parks');
    cy.get('[type="password"]').type('bus');
  });
});


When('I click on the {string} button', (buttonName) => {
  cy.contains('button', buttonName).click();
  //cy.get(`button[value="${buttonName}"]`).click();
  //cy.get(`button[value="${buttonName}"]`).first().click(); 

});

When ('I click on {string}', (phrase)=> {
  cy.get(`button[value="${phrase}"]`).click();
})


Then('I should see the Min sida title', () => {
  cy.get('[href="/users/:id"]').should('have.text', 'Min sida')
});
