Feature: Create ad
  user creates a new ad

  Scenario: Create and save ad after logging in
    Given I am on the "/" page
    When I log in
    When I click on Skapa annons
    And I am redirected to the "createAd" page
    And I click on the "Continue" button
    And I should see "(2)"
    And I click on the "Continue" button
    And I should see "(3)"
    And I click on the "Continue" button
    And I should see "(4)"
    And I click on the "Continue" button
    And I should see "(5)"
    And I click on the "Continue" button
    And I am redirected to the "publicera din annons" page
    And I mark "Spara"
    And I click on the "Submit" button
    Then I should see "Din annons har sparats"

  Scenario: Create and publish ad after logging in
    Given I am on the "/" page
    When I log in
    When I click on Skapa annons
    And I am redirected to the "createAd" page
    And I click on the "Continue" button
    And I should see "(2)"
    And I click on the "Continue" button
    And I should see "(3)"
    And I click on the "Continue" button
    And I should see "(4)"
    And I click on the "Continue" button
    And I should see "(5)"
    And I click on the "Continue" button
    And I am redirected to the "publicera din annons" page
    And I mark "Publicera"
    And I choose an end date
    And I click on the "Submit" button
    Then I should see "Tack!"