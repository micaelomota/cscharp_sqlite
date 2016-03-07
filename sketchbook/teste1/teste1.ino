
void setup()
{
  Serial.begin(9600);  //inicia comunicação serial com 9600
  pinMode(13, OUTPUT);
}
 
void loop()
{
  if(Serial.available())        //se algum dado disponível
  {
    char c = Serial.read();   //le o byte disponivel

    switch(c){
      case 'L': digitalWrite(13, HIGH); Serial.println("Ligando LED"); break;
      case 'D': digitalWrite(13, LOW);  Serial.println("Desligando LED"); break;
      default:  Serial.println("Comando invalido"); 
    }
    
    
  }
}
