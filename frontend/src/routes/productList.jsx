import { useState } from "react";
import { Row, Button, Col } from "react-bootstrap";

import Filter from "../components/Filter";
import ProductsTable from "../components/ProductsTable";

export default function ProductList({ nextPath }) {
  const [nameFilter, setNameFilter] = useState("");

  function handleNameFilterChange(value) {
    setNameFilter(value);
  }

  return (
    <div>
      <h3> Product List</h3>
      <Row>
        <Filter property={"Name"} changeMethod={handleNameFilterChange} />
        <Col>
          <Button onClick={() => nextPath("/newProduct")} variant="success">
            New Product
          </Button>
        </Col>
      </Row>
      <Row>
        <ProductsTable nameFilter={nameFilter} nextPath={nextPath} />
      </Row>
    </div>
  );
}
