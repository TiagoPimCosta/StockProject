import { render, fireEvent } from "@testing-library/react";
import NewProduct from "../../routes/newProduct";

describe("NewProduct", () => {
  it("Button disable on render", () => {
    const { getByTestId } = render(<NewProduct />);
    const button = getByTestId("submitButton");
    expect(button).toHaveProperty("disabled");
  });
});
