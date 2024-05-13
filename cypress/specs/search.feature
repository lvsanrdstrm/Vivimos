Feature: Search
  User searches the site for specific terms

  Scenario: Search for a term
    Given I am on the "/" page
    When I search for "halland"
    Then I should see "Halland" in the search results