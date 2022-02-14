import { useNavigate } from 'react-router-dom';

import { Row, Col, Form, Button} from 'react-bootstrap';

export default function NewProduct() {
  
  let navigate = useNavigate();

  function nextPath(path) {
    navigate(path);
  }

  return (
    <Row >

      <Col  md={{ span: 6, offset: 3 }}>
        <h3> New Product </h3>
      </Col>

      <Col  md={{ span: 6, offset: 3 }}>
        <Form>
          <Form.Group className="mb-3">   {/* Name */}
            <Form.Label htmlFor="inputPassword5">Name</Form.Label>
            <Form.Control
              type="text"
              id="name"
            />
          </Form.Group>

          <Form.Group className="mb-3">   {/* Color */}
            <Form.Label htmlFor="inputPassword5">Color</Form.Label>
            <Form.Control
              type="text"
              id="color"
            />
          </Form.Group>

          <Form.Group className="mb-3">   {/* Price */}
            <Form.Label htmlFor="inputPassword5">Price</Form.Label>
            <Form.Control
              type="text"
              id="price"
            />
          </Form.Group>
          
          <Form.Group className="mb-3">   {/* Description */}
            <Form.Label htmlFor="inputPassword5">Description</Form.Label>
            <Form.Control
              type="text"
              id="description"
            />
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
  );
}