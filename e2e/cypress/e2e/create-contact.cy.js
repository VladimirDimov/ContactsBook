import { expect } from "chai";
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

    cy.get("#firstName").type("Claude");
    cy.get("#lastName").type("Monet");
    cy.get("#dateOfBirth").type("11/14/1840");
    cy.get("#phoneNumber").type("111-222222");
    cy.get("#iban").type("NL39ABNA9403840137");
    cy.get(`p-button[label="Submit"`).click();
    cy.get("tr")
      .last()
      .within(() => {
        cy.get("td").then((td) => {
          cy.get(td[0]).contains("Claude");
          cy.get(td[1]).contains("Monet");
          cy.get(td[2]).contains("14-11-1840");
          cy.get(td[3]).contains("111-222222");
          cy.get(td[4]).contains("NL39ABNA9403840137");

          // clean after assert
          cy.get('p-button[icon="pi pi-trash"]').click();
        });
      });
  });
});
