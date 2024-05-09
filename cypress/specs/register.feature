Feature: Register
  Register new user

  Scenario:
    Given I am on the "/" page
    And I click on the "Registrera dig" button
    And a register modal pops up
    And I type in my username, email, and password
    And I click on the "Registrera" button
    Then I should see a "Min sida" title