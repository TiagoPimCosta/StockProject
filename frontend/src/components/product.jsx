import React from "react";

import { Button } from "react-bootstrap";

function Product(props) {
  return (
    <tr>
      <td data-testid="name">{props.product.name}</td>
      <td data-testid="colour">{props.product.colour}</td>
      <td data-testid="price">{props.product.price + "€"}</td>
      <td data-testid="brand">{props.product.brand}</td>
      <td data-testid="quantity">{props.product.quantity}</td>
      <td>
        <Button
          data-testid="stockButton"
          onClick={() => props.nextPath(`/stock/${props.product.name}`)}
          variant="primary"
        >
          Stock
        </Button>
      </td>
    </tr>
  );
}

export default Product;
