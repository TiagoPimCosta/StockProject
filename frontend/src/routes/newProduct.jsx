import { useNavigate } from 'react-router-dom';
import { useState, useEffect } from 'react';

import { Row, Col, Form, Button} from 'react-bootstrap';

import { addProduct } from '../services/productService';
import FormField from '../components/FormField';

export default function NewProduct() {
  
  let navigate = useNavigate();

  const [name, setName] = useState("");
  const [colour, setColour] = useState("");
  const [brand, setBrand] = useState("");
  const [price, setPrice] = useState("");
  const [description, setDescription] = useState("");

  useEffect(()=>{
    verifyForm();
  },[name, colour, brand, price, description]);

  function nextPath(path) {
    navigate(path);
  }

  function verifyForm(){  //Check if all inputs are filled
    if(name && colour && brand && price && description){
      return true;
    }else{
      return false;
    }
  }

  // Hook Changes

  function handleNameChange(event){
    setName(event.target.value);
  }
  function handleColourChange(event){
    setColour(event.target.value);
  }
  function handleBrandChange(event){
    setBrand(event.target.value);
  }
  function handlePriceChange(event){
    setPrice(event.target.value);
  }
  function handleDescriptionChange(event){
    setDescription(event.target.value);
  }

  const submitButton = verifyForm() ? <Button  onClick={() => nextPath('/')}  variant="success" >Save</Button>
                                    : <Button  onClick={() => nextPath('/')}  variant="success" disabled>Save</Button>

  return (
    <>
      <Row >
        <Col  md={{ span: 6, offset: 3 }}>
          <h3> New Product </h3>
        </Col>
      </Row >
      <Row >
        <Col md={{ span: 6, offset: 3 }}>
          <Form>
            <FormField inputName={"Name"} text={name} method={handleNameChange}/>
            <FormField inputName={"Colour"} text={colour} method={handleColourChange}/>
            <FormField inputName={"Price"} text={price} method={handlePriceChange}/>
            <FormField inputName={"Brand"} text={brand} method={handleBrandChange}/>
            <FormField inputName={"Description"} text={description} method={handleDescriptionChange}/>
            <div>
              { submitButton }{' '}
              <Button  onClick={() => nextPath('/')}  variant="danger">Cancel</Button>
            </div>
          </Form>
        </Col>
      </Row>
    </>
  );
}