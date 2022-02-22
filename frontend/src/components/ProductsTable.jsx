import { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import { getProducts } from "../services/productService";
import Product from "../components/Product";

export default function ProductsTable({ nameFilter, nextPath }) {
  const [products, setProducts] = useState([]);

  useEffect(() => {
    getProducts().then((response) => {
      setProducts(response);
    });
  }, []);

  const filteredproducts = nameFilter
    ? products.filter((product) =>
        product.name.toLowerCase().includes(nameFilter.toLowerCase())
      )
    : products;

  return (
    <div>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Name</th>
            <th>Colour</th>
            <th>Price</th>
            <th>Brand</th>
            <th>Quantity</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {filteredproducts.map((product, idx) => (
            <Product key={idx} product={product} nextPath={nextPath} />
          ))}
        </tbody>
      </Table>
    </div>
  );
}
