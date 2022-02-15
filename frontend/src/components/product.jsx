import React from 'react'

import { Button } from 'react-bootstrap';

 function Product(props) {
  return (
    <tr >
      <td>{props.product.name}</td>
      <td>{props.product.colour}</td>
      <td>{props.product.price+"€"}</td>
      <td>{props.product.brand}</td>
      <td>{props.product.quantity}</td>
      <td><Button onClick={() => props.nextPath(`/stock/${props.product.name}`)} variant="primary">Stock</Button></td>
    </tr>
  )
}

export default Product;