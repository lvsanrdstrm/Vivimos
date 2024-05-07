Feature: Ads

    Scenario: See the list of ads on the first page
        Given that I am on the vivimos page
        When I click on Hem
        Then I can see the list of ads

    Scenario: See an individual ad
        Given I am on the vivimos page
        When I click on the headline on an ad
        Then I should see a detailed description of the ad

    Scenario: Create and save ad when logged in
        Given I am logged in
        And I am on the Skapa annons-page
        When I enter the ad-details
        And I choose the "Spara annons" option
        And I click on "Submit"
        Then a "Din annons har sparats" message should show

    Scenario: Create and publish ad when logged in
        Given I am logged in
        And I am on the Skapa annons-page
        When I enter the ad-details
        And I choose the "Publicera annons" option
        And I enter a finish-date for my ad
        And I click on "Submit"
        Then a "Tack! Din annons har nu publicerats!" message should show