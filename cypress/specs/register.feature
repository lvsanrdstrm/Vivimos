Feature: Register
  Register new user

  Scenario:
    Given I am on the "/" page
    And I click on the "Registrera dig" button
    And a login modal pops up
    And I type in my username and password
    And I click on the "Login" button
    Then I should see a "Min sida" title