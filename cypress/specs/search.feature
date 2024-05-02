Feature: Search

  Scenario: Search for a term
    Given I am on the "/" page
    When I search for "Skåne"
    Then I should see "Skåne" in the search results

  Scenario Outline: Search for some terms
    Given I am on the "/" page
    When I search for "<searchTerm>"
    Then I should see "<searchTerm>" in the search results

    Examples:
      | searchTerm |
      | Skåne      |
      | Halland    |
      | Gotland    |

