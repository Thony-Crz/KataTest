Feature: Trail Race Manager
As a trail race organizer
I want to manage a list of trail runners
So that I can track their information and performance

    Scenario: Add and find a trail runner
        Given a trail race manager
        When I add a trail runner named "Alice Johnson" with age 28, location "New York", and best time 45.5 minutes
        Then the trail runner "Alice Johnson" should be in the list
