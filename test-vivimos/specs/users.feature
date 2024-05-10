Feature: User actions

  Scenario: Log in
    Given I am on the "/" page
    When I click on the "Logga in" button
    And a "login" modal pops up
    And I enter user credentials
    And I click on the "Log in" button
    Then I should seen the Min sida title

  Scenario: Register user
    Given I am on the "/" page
    When I click on "Registrera dig" button
    And a "register" modal pops up
    And I enter my user credentials
    And I click on the "Registrera" button
    Then I should seen a "Min sida" title