const { homeUrl, baseUrl, aboutUrl } = require("./constants");

describe("root url is working", () => {
  it("passes", () => {
    cy.visit(baseUrl);
  });
});

describe("home url is working", () => {
  it("passes", () => {
    cy.visit(baseUrl + homeUrl);
  });
});

describe("header navigation should work properly", () => {
  it("passes", () => {
    cy.visit(baseUrl);

    // navigate to /home
    cy.get(`a[href="${homeUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + homeUrl);

    // navigate to /about
    cy.get(`a[href="${aboutUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + aboutUrl);
  });
});

describe("header navigation should work properly", () => {
  it("passes", () => {
    cy.visit(baseUrl);

    // navigate to /home
    cy.get(`a[href="${homeUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + homeUrl);

    // navigate to /about
    cy.get(`a[href="${aboutUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + aboutUrl);
  });
});

describe("header navigation should work properly", () => {
  it("passes", () => {
    cy.visit(baseUrl);

    // navigate to /home
    cy.get(`a[href="${homeUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + homeUrl);

    // navigate to /about
    cy.get(`a[href="${aboutUrl}"]`).click();
    cy.location("href").should("eq", baseUrl + aboutUrl);
  });
});
