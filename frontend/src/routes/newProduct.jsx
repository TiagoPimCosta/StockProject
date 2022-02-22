import { useState } from 'react';

import { Row, Col, Form, Button} from 'react-bootstrap';

import { addProduct } from '../services/productService';
import FormField from '../components/FormField';

export default function NewProduct({nextPath}) {

  const [name, setName] = useState("");
  const [colour, setColour] = useState("");
  const [brand, setBrand] = useState("");
  const [price, setPrice] = useState("");
  const [description, setDescription] = useState("");

  function verifyForm(){  //Check if required inputs are filled
    if(name && colour && brand && price){
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

  async function submitForm(){
    await addProduct(name, colour, parseFloat(price), 0, brand, description);  
    nextPath('/');
  };

  const submitButton = verifyForm() ? <Button  onClick={() => submitForm()}  variant="success" data-testid="submitButton">Save</Button>
                                    : <Button  variant="success" data-testid="submitButton" disabled>Save</Button>

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
            <FormField type={"text"} inputName={"Name"} text={name} method={handleNameChange}/>
            <FormField type={"text"} inputName={"Colour"} text={colour} method={handleColourChange}/>
            <FormField type={"number"} inputName={"Price"} text={price} method={handlePriceChange}/>
            <FormField type={"text"} inputName={"Brand"} text={brand} method={handleBrandChange}/>
            <FormField type={"text"} inputName={"Description"} text={description} method={handleDescriptionChange}/>
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