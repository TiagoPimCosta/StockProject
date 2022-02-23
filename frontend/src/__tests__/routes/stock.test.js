import { render, fireEvent } from "@testing-library/react";
import Stock from "../../routes/stock";

describe("Stock", () => {
  it("Button disable on render", () => {
    const { getByTestId } = render(<Stock />);
    const button = getByTestId("submitButton");
    expect(button).toHaveProperty("disabled");
  });

  it("Correct select value", () => {
    const { getByTestId } = render(<Stock />);

    const select = getByTestId("stockSelect");
    const input = getByTestId("quantityInput");
    const button = getByTestId("submitButton");

    fireEvent.change(input, { target: { value: 50 } }); // Change input value
    fireEvent.change(select, { target: { value: "Stock In" } }); // Change select value

    expect(button).toHaveProperty("disabled");
  });

  it("Correct input value", () => {
    const { getByTestId } = render(<Stock />);

    const input = getByTestId("quantityInput");
    fireEvent.change(input, { target: { value: 50 } }); // Change input value
    expect(input.value).toBe("50");
  });
});
