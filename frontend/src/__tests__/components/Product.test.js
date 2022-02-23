import { render } from "@testing-library/react";
import Product from "../../components/Product";

import { useNavigate } from "react-router-dom";

const product = {
  name: "T-Shirt",
  colour: "Black",
  price: 15.5,
  brand: "Adidas",
  quantity: 50,
};

describe("Product", () => {
  it("Labels correct values", () => {
    const { getByTestId } = render(<Product product={product} />);

    const name = getByTestId("name");
    const colour = getByTestId("colour");
    const price = getByTestId("price");
    const brand = getByTestId("brand");
    const quantity = getByTestId("quantity");

    expect(name.textContent).toBe("T-Shirt");
    expect(colour.textContent).toBe("Black");
    expect(price.textContent).toBe("15.5€");
    expect(brand.textContent).toBe("Adidas");
    expect(quantity.textContent).toBe("50");
  });
  /*
  it("Button correct method", () => { // Problemas
    const { getByTestId } = render(<Product product={product} />);

    const stockButton = getByTestId("stockButton");

    console.log(stockButton.simulate("click"));
    button.simulate("click");
    //expect(stockButton).toBe("50");
  });
*/
});
