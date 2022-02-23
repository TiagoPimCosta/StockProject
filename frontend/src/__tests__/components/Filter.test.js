import { render } from "@testing-library/react";
import Filter from "../../components/Filter";

describe("Filter", () => {
  it("Correct label value", () => {
    const { getByTestId } = render(
      <Filter property={"Name"} /* changeMethod={handleNameFilterChange}*/ />
    );

    const labelFilter = getByTestId("labelFilter");
    expect(labelFilter.textContent).toBe("Name");
  });
});
