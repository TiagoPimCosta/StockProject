import { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Row, Col, Form, Button } from 'react-bootstrap';

import { getProductDetails, stockIn, stockOut } from "../services/productService";

export default function Stock(props) {

  var params = useParams();
  let navigate = useNavigate();

  const [product, setProduct] = useState([]);
  const [stock, setStock] = useState("");
  const [type, setType] = useState("");

  const [error, setError] = useState(false);
  const [errorMessage, setErrorMessage] = useState("")

  useEffect(() => { // UseEffect to fetch product details
    getProductDetails(params.name).then((response) => {
      setProduct(response);
    });
    setError(true);
    validateStock();
  }, []);

  useEffect(() => { // UseEffect to validateStock
    validateStock();
  }, [type, stock]);

  function nextPath(path) {
    navigate(path);
  }

  function isValue(value) { // Return true if value param is a Number
    if (typeof value !== 'string') {
      return false;
    }

    const num = Number(value);

    if (Number.isInteger(num) && num > 0) {
      return true;
    }
    console.log("");
    return false;
  }

  function validateStock() {
    if (isValue(stock)) {
      if (stock > product.quantity && type === "Stock Out") {
        setError(true);
        setErrorMessage("The maximum available stock is " + product.quantity + " units!");
      } else {
        setError(false);
        setErrorMessage("");
      }
    } else {
      setError(true);
      setErrorMessage("Please enter a positive integer value!");
    }
  }

  function handleStockChange(event) {
    setStock(event.target.value);
  }

  function handleTypeChange(event) {
    setType(event.target.value);
  }

  function submitForm() {
    if (!error) {
      if (type === "Stock In") {
        stockIn(product.name, stock);
        nextPath('/');
      } else {
        stockOut(product.name, stock);
        nextPath('/');
      }
    }
  }

  const message = error ? <Form.Text className="text-error">
    {errorMessage}
  </Form.Text>
    : null;

  const submitButton = error || !type ? <Button variant="success" disabled >Save</Button>
    : <Button onClick={submitForm} variant="success">Save</Button>

  return (
    <>
      <Row >
        <Col md={{ span: 6, offset: 3 }}>
          <h3> Stock </h3>
        </Col>
      </Row>
      <Row >
        <Col md={{ span: 6, offset: 3 }}>
          <Form>
            <Form.Group className="mb-3">
              <Form.Label htmlFor="disabledTextInput">Product</Form.Label>
              <Form.Control id="product" placeholder={product.name} disabled />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label >Quantity</Form.Label>
              <Form.Control
                type="number"
                placeholder="Quantity"
                onChange={handleStockChange} />
              {message}
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Type</Form.Label>
              <Form.Select onChange={handleTypeChange}>
                <option value={""}>Select...</option>
                <option value={"Stock In"}>Stock In</option>
                <option value={"Stock Out"}>Stock Out</option>
              </Form.Select>
            </Form.Group>
            <div>
              {submitButton}{' '}
              <Button className="right-Button" onClick={() => nextPath('/')} variant="danger">Cancel</Button>
            </div>
          </Form>
        </Col>
      </Row>
    </>
  )
}