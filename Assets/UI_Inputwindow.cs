using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inputwindow : MonoBehaviour
{
	public Button Ok, Cancel;
	public InputField R1Input,VoInput,IoInput,PoInput,VblInput,IblInput,PblInput;
	private Text R1Value,VoValue,IoValue,PoValue,VblValue,IblValue,PblValue;
	
	/*
	public InputField VoInput;
	private Text VoValue;
	public InputField IoInput;
	private Text IoValue;
	public InputField PoInput;
	private Text PoValue;
	public InputField VblInput;
	private Text VblValue;
	public InputField IblInput;
	private Text IblValue;
	public InputField PblInput;
	private Text PblValue;*/
	
    private void Start() {
		Hide(); // keep the form hide from screen
		Ok.onClick.AddListener(RecordParameters);
		Cancel.onClick.AddListener(Hide);
		R1Value = R1Input.textComponent;
		VoValue = VoInput.textComponent;
		IoValue = IoInput.textComponent;
		PoValue = PoInput.textComponent;
		VblValue = VblInput.textComponent;
		IblValue = IblInput.textComponent;
		PblValue = PblInput.textComponent;
	}
	
	private void RecordParameters(){
		//Debug.Log(VoValue.text);
		Hide();
		Calc();
	}
	
	
	private void Calc(){
		float R1 = float.Parse(R1Value.text);
		float Vo = float.Parse(VoValue.text);
		float Io = float.Parse(IoValue.text);
		float Po = float.Parse(PoValue.text);
		float Vbl = float.Parse(VblValue.text);
		float Ibl = float.Parse(IblValue.text);
		float Pbl = float.Parse(PblValue.text);
		Debug.Log(Pbl);
		Debug.Log(Mathf.Pow(Ibl,1.0f));
		Debug.Log(R1);
		float R2linha = (Pbl/Mathf.Pow(Ibl,2.0f)) - R1;
		Debug.Log(R2linha);
		var Zbl = Vbl/Ibl;
		//Debug.Log(Zbl);
		var X1 = 0.5*Mathf.Sqrt(Mathf.Pow(Zbl,2.0f)-Mathf.Pow(R1+R2linha,2.0f));
		//Debug.Log(X1);
		var X2linha = X1;
		//Debug.Log(X2linha);
		float Zo = Vo/Io;
		float Ro = Po/Mathf.Pow(Io,2.0f);
		var Xmag = 2*(Mathf.Sqrt(Mathf.Pow(Zo,2.0f))-Mathf.Pow(Ro,2.0f))-(X1+0.5*X2linha);
		//Debug.Log(Xmag);
	}
	
	public void Show() {
		gameObject.SetActive(true);
	}
	
	public void Hide() {
		gameObject.SetActive(false);
	}
}
