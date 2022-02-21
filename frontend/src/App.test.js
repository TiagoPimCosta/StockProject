import { render, fireEvent } from '@testing-library/react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

import FormField from './components/FormField';
import NewProduct from './routes/newProduct';
import Stock from'./routes/stock';

describe("FormField",()=>{

  it("Label correct value",()=>{
    const { getByTestId } = render(<FormField inputName={"Name"}/>);
    const label = getByTestId('label')
    expect(label.textContent).toBe("Name");
  });

  it("Input correct type",()=>{
    const { getByTestId } = render(<FormField type={"text"}/>);
    const input = getByTestId('customInput')
    expect(input).toHaveProperty("type","text");
  });

  it("Input correct id",()=>{
    const { getByTestId } = render(<FormField text={"id"}/>);
    const input = getByTestId('customInput')
    expect(input).toHaveProperty("id","id");
  });

  /*
  it("Input onChangeMethod working",()=>{
    const { getByTestId } = render(<FormField type={"text"} inputName={"Name"} text={"Name"}/>);
    const input = getByTestId('customInput')
    expect(input).toHaveProperty("onChange","Method");
  });
  */
});


describe("NewProduct",()=>{
  
  it("Button disable on render",()=>{
      const { getByTestId } = render(<BrowserRouter><NewProduct /></BrowserRouter>);
      const button = getByTestId('submitButton')
      expect(button).toHaveProperty("disabled");
  });
});

describe("Stock",()=>{
  
  it("Button disable on render",()=>{
      const { getByTestId } = render(<BrowserRouter><Stock /></BrowserRouter>);
      const button = getByTestId('submitButton')
      expect(button).toHaveProperty("disabled");
  });
  
  it("Correct select value",()=>{
    const { getByTestId } = render(<BrowserRouter><Stock /></BrowserRouter>); 
    
    const select = getByTestId('stockSelect')
    const input = getByTestId('quantityInput');
    const button = getByTestId('submitButton')
    
    fireEvent.change(input, {target: {value: 50}}); // Change input value
    fireEvent.change(select, {target: {value: 'Stock In'}}); // Change select value
    
    expect(button).toHaveProperty("disabled");
  })

  it("Correct input value",()=>{
    const { getByTestId } = render(<BrowserRouter><Stock /></BrowserRouter>); 
    
    const input = getByTestId('quantityInput');
    fireEvent.change(input, {target: {value: 50}}); // Change input value
    expect(input.value).toBe("50");
  })
});