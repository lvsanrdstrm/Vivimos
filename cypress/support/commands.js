Cypress.Commands.add('login', () => {
  cy.get('.loginButton').click();
  cy.get('.modal-body').should('be.visible');
  cy.get('.modal-body').within(() => {
    cy.get('form > [type="text"]').type('rosa.parks');
    cy.get('[type="password"]').type('bus');
  });
  cy.get('.modal-body').within(() => {
    cy.get('form > button').click();
  });
});

Cypress.Commands.add('buttonByIndex', (index) => {
  return cy.get(`:nth-child(${index}) > input`);
});

Cypress.Commands.add('clickButtonByText', (buttonText) => {
  cy.get(`input[value="${buttonText}"], button:contains("${buttonText}")`).click();
});
