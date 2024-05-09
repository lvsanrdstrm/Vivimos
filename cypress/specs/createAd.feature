Feature: Create ad
  user creates a new ad

  Scenario: Create ad after logging in
    Given I am on the "/" page
    When I log in
    When I click on the "skapa annons" nav title
    And I am redirected to the "createAd" page
    And I click on the continue button
    And I am redirected to the second page
    And I click on the continue button
    And I am redirected to the third page
    And I click on the continue button
    And I am redirected to the fourth page
    And I click on the continue button
    And I am redirected to the fifth page
    And I click on the continue button
    And I am redirected to the final page
    And I mark "Spara"
    And I click on "Submit"
    Then a "Din annons har sparats!" message should show