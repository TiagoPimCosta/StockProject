import { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { Row, Col, Form, Button} from 'react-bootstrap';

import { getProductDetails } from "../services/data";

export default function Stock(props) {

  let params = useParams();
  console.log(params);
  const [product, setProduct] = useState(getProductDetails(params.id));


  let navigate = useNavigate();

  function nextPath(path) {
    navigate(path);
  }
 
  return (
    <Row >

      <Col  md={{ span: 6, offset: 3 }}>
        <h3> Stock </h3>
      </Col>

      <Col  md={{ span: 6, offset: 3 }}>
        <Form>
            <Form.Group className="mb-3">
              <Form.Label htmlFor="disabledTextInput">Product</Form.Label>
              <Form.Control id="product" placeholder={product.name} disabled />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label htmlFor="disabledTextInput">Quantity</Form.Label>
              <Form.Control id="quantity" placeholder="Quantity" />
            </Form.Group>
            <Form.Group className="mb-3">
              <Form.Label>Type</Form.Label>
              <Form.Select >
                <option value={""}>Select...</option>
                <option value={""}>Stock In</option>
                <option value={""}>Stock Out</option>
              </Form.Select>
            </Form.Group>
            <Row >
              <Col md={{ span: 2, offset: 8 }}>
                <Button  onClick={() => nextPath('/')}  variant="success">Save</Button>
              </Col>
              <Col md={{ span: 2}}>
                <Button  onClick={() => nextPath('/')}  variant="danger">Cancel</Button>
              </Col>
            </Row>
        </Form>
      </Col>
    </Row>
  )
}