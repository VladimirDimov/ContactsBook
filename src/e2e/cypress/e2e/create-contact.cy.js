import { aboutUrl, baseUrl, homeUrl } from "./constants";

describe("add contact dialog opens correctly", () => {
  it("passes", () => {
    cy.visit(baseUrl);

    // navigate to /home
    cy.get(`a[href="${homeUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + homeUrl);

    // navigate to /about
    cy.get(`p-button[label="Add Contact"`).click();
    cy.get("app-add-contact");
  });
});

describe("user can create contact", () => {
  it("passes", () => {
    cy.visit(baseUrl);

    // navigate to /home
    cy.get(`a[href="${homeUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + homeUrl);

    // navigate to /about
    cy.get(`p-button[label="Add Contact"`).click();

    cy.get("#firstName");
  });
});
