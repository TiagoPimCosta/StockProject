import { render, screen, cleanup } from '@testing-library/react';

import FormField from './components/FormField';

describe("FormField",()=>{
  it("Label working",()=>{
    const { getByTestId } = render(<FormField type={"text"} inputName={"Name"} text={"id"}/>);
    const input = getByTestId('label')
    expect(input.textContent).toBe("Name");
  });

  it("Input type working",()=>{
    const { getByTestId } = render(<FormField type={"text"} inputName={"Name"} text={"id"}/>);
    const input = getByTestId('customInput')
    expect(input).toHaveProperty("type","text");
  });

  it("Input id working",()=>{
    const { getByTestId } = render(<FormField type={"text"} inputName={"Name"} text={"id"}/>);
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