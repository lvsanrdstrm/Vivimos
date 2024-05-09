Feature: Create ad
  user creates a new ad

  Scenario: Create ad after logging in
    Given I am on the "/" page
    When I log in
    When I click on the "skapa annons" nav title
    And I am redirected to the "createAd" site
    And I mark a gender option
    And I choose an age
    And I click on the "continue" button
    And I am redirected to the second page
    And I choose a county
    And I mark a type of dwelling
    And I choose a city size
    And I mark a type of nearby attractions
    And I click on the "continue" button
    And I am redirected to the third page
    And I fill in my occupation
    And I fill in my hobbies
    And I click on the "continue" button
    And I am redirected to the fourth page
    And I mark a relationship status option
    And I click on the "continue" button
    And I am redirected to the fifth page
    And I write a text about myself
    And I write a catchy ad title 
    And I click on the "continue" button
    And I am redirected to the final page
    And I mark "Publicera"
    And I choose a date
    And I click on "Submit"
    Then a "Tack! Din annons har publicerats!" alert should pop up