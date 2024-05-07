Feature: Ads

    Scenario: See the list of ads on the first page
        Given that I am on the vivimos page
        When I click on Hem
        Then I can see the list of ads

    Scenario: See an individual ad
        Given I am on the vivimos page
        When I click on the headline on an ad
        Then I should see a detailed description of the ad