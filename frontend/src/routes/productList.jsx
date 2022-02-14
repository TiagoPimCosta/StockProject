import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';

import { Row, Button, Col, Table, InputGroup, FormControl} from 'react-bootstrap';

import { getProducts } from "../services/productService";

import Product from '../components/product';

export default function ProductList() {
  let navigate = useNavigate();

  const [products, setProducts] = useState([]);
  const [nameFilter, setNameFilter] = useState("");

  useEffect(()=>{
    getProducts().then((response) => {
      setProducts(response);
    });
  },[]);

  function nextPath(path) {
    navigate(path);
  }

  const filteredproducts = nameFilter ? products.filter(product => product.name.toLowerCase().includes(nameFilter.toLowerCase())) 
                                      : products;

  return (
    <div>
      <h3> Product List</h3>
      <Row>
        <Col sm={8}><InputGroup className="mb-3">
            <InputGroup.Text id="inputGroup-sizing-default" >Name</InputGroup.Text>
            <FormControl
              aria-label="Default"
              aria-describedby="inputGroup-sizing-default"
              onChange={event => setNameFilter(event.target.value)}
            />
          </InputGroup></Col>
        <Col sm={4}>
          <Button onClick={() => nextPath('/newProduct')} variant="success">New Product</Button>
        </Col>
        
      </Row>

      <Row>
        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Name</th>
              <th>Color</th>
              <th>Price</th>
              <th>Brand</th>
              <th>Quantity</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {
              filteredproducts.map(product => (
                <Product key={product.id} product = {product} nextPath={nextPath}/>
             ))
            }
          </tbody>
        </Table>
      </Row>
      
    </div>
  );
}