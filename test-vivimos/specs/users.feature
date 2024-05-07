Feature: User actions

  Scenario: Log in
    Given I am on the vivimos page
    When I click on Log in
    And I enter user credentials
    And I click on log in
    Then I should be logged in

  Scenario: Register user
    Given I am on the vivimos page
    When I click on "Registrera dig"
    And I enter my user credentials
    And I click on "Registrera"
    Then I should have registrered a new users