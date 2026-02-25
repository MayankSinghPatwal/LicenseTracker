from dotenv import load_dotenv
import streamlit as st
import os
from PIL import Image
import google.generativeai as genai



load_dotenv() # load all environment variables from .env file


# configuring api key
genai.configure(api_key=os.getenv('GOOGLE_API_KEY'))

# function to load gemini pro vision model and get response
def get_gemini_response(input, image, prompt):
    # load gemini pro vision model
    model = genai.GenerativeModel('gemini-1.5-flash')
    response = model.generate_content([input, image[0], prompt])
    return response.text


def input_image_setup(uploaded_file):
    if uploaded_file is not None:
        # read the file into bytes
        bytes_data = uploaded_file.getvalue()

        image_parts = [
            {
                "mime_type": uploaded_file.type,  # get the mime type of uploaded file
                "data": bytes_data
            }
        ]
        return image_parts
    else:
        raise FileNotFoundError("No File Found")
    



# initializing our streamlit app

st.set_page_config(page_title="Gemini Image Demo")
st.header("License Track AI")
input = st.text_input("Input Prompt: ", key="input")
uploaded_file = st.file_uploader("choose an image...", type=["jpg", "jpeg", "png"])
image = ""

if uploaded_file is not None:
    image = Image.open(uploaded_file)
    st.image(image, caption="uploaded image.", use_column_width=True)


submit = st.button("Tell me about the invoice")


input_prompt = """ You are an expert in understanding invoices.
You will receive input files (images or PDFs) as invoices 
and you will have to answer questions based on the input file.
"""


# if submit button is clicked

if submit:
    image_data = input_image_setup(uploaded_file)
    response = get_gemini_response(input_prompt, image_data, input)
    st.subheader("The Response is")
    st.write(response) 




