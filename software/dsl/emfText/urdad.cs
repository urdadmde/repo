SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>

// IMPORTS { java : <http://www.emftext.org/java> 
// <../../org/urdad/language/urdad/metamodel/urdad.genmodel> 
// WITH SYNTAX java <../../org/urdad/language/someOtherLanguage/metamodel/someOtherLanguage.cs>}


START Model

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


TOKENSTYLES {
	"Model" COLOR #7F0055, BOLD;
	"ResponsibilityDomain" COLOR #7F0055, BOLD;
	"Query" COLOR #7F0055, BOLD;
	"Constraint" COLOR #7F0055, BOLD;
	"Condition" COLOR #7F0055, BOLD;
	"QualityConstraint" COLOR #7F0055, BOLD;
	"FunctionalRequirements" COLOR #7F0055, BOLD;
	"receiving" COLOR #7F0055, BOLD;
	"yielding" COLOR #7F0055, BOLD;
	"stateAssessmentProcess" COLOR #7F0055, BOLD;
	"from" COLOR #7F0055, BOLD;
	"to" COLOR #7F0055, BOLD;
	"many" COLOR #7F0055, BOLD;
	"BasicDataType" COLOR #7F0055, BOLD;
	"DataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"abstract" COLOR #7F0055, BOLD;
	"has" COLOR #7F0055, BOLD;
	"Variable" COLOR #7F0055, BOLD;
	"ofType" COLOR #7F0055, BOLD;
	"Constant" COLOR #7F0055, BOLD;
	"ValueOf" COLOR #7F0055, BOLD;
	"Exception" COLOR #7F0055, BOLD;
	"attribute" COLOR #7F0055, BOLD;
	"association" COLOR #7F0055, BOLD;
	"identifying" COLOR #7F0055, BOLD;
	"aggregate" COLOR #7F0055, BOLD;
	"component" COLOR #7F0055, BOLD;
	"QualityRequirement" COLOR #7F0055, BOLD;
	"requiredBy" COLOR #7F0055, BOLD;
	"PreCondition" COLOR #7F0055, BOLD;
	"raises" COLOR #7F0055, BOLD;
	"checks" COLOR #7F0055, BOLD;
	"PostCondition" COLOR #7F0055, BOLD;
	"ensures" COLOR #7F0055, BOLD;
	"use" COLOR #7F0055, BOLD;
	"toAddress" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"ServiceContract" COLOR #7F0055, BOLD;
	"undoneUsing" COLOR #7F0055, BOLD;
	"Request" COLOR #7F0055, BOLD;
	"Result" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"realizes" COLOR #7F0055, BOLD;
	"doSequential" COLOR #7F0055, BOLD;
	"choice" COLOR #7F0055, BOLD;
	"else" COLOR #7F0055, BOLD;
	"doConcurrent" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"Concurrency" COLOR #7F0055, BOLD;
	"wait" COLOR #7F0055, BOLD;
	"until" COLOR #7F0055, BOLD;
	"create" COLOR #7F0055, BOLD;
	"set" COLOR #7F0055, BOLD;
	"equalTo" COLOR #7F0055, BOLD;
	"add" COLOR #7F0055, BOLD;
	"remove" COLOR #7F0055, BOLD;
	"requestService" COLOR #7F0055, BOLD;
	"with" COLOR #7F0055, BOLD;
	"on" COLOR #7F0055, BOLD;
	"raiseException" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"forAll" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
	"constructedUsing" COLOR #7F0055, BOLD;
	"ConditionReference" COLOR #7F0055, BOLD;
	"annotations" COLOR #7F0055, BOLD;
	"constructConditionParameterProcess" COLOR #7F0055, BOLD;
	"parameter" COLOR #7F0055, BOLD;
	"condition" COLOR #7F0055, BOLD;
	"ResultConstraint" COLOR #7F0055, BOLD;
	"constraintExpression" COLOR #7F0055, BOLD;
	"NotCondition" COLOR #7F0055, BOLD;
	"operand" COLOR #7F0055, BOLD;
	"AndCondition" COLOR #7F0055, BOLD;
	"leftOperand" COLOR #7F0055, BOLD;
	"rightOperand" COLOR #7F0055, BOLD;
	"OrCondition" COLOR #7F0055, BOLD;
	"XorCondition" COLOR #7F0055, BOLD;
	"InverseCondition" COLOR #7F0055, BOLD;
	"inverseOf" COLOR #7F0055, BOLD;
	"AND" COLOR #7F0055, BOLD;
	"OR" COLOR #7F0055, BOLD;
	"XOR" COLOR #7F0055, BOLD;
	"TypeIdentifier" COLOR #7F0055, BOLD;
	"type" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)* 
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(responsibilityDomains | conditions | dataTypes | servicesContracts | services | annotations)*"}"; 

	Expression ::= language [] ":" expressionString['"','"'];
	
	Query ::= "Query" (name[])? (queryExpression);
	
	ExpressionBasedConstraint ::= "Constraint" (name[])? (constraintExpression)? 
	  ("(" (annotations)*")")?;	
	
	QualityConstraint ::= "QualityConstraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;

	FunctionalRequirements ::= "FunctionalRequirements"
		("receiving" (requestVariable))?
		("yielding" (resultVariable))? 
	"{"
		 (preConditions)*
		 (postConditions)*
	"}";

	Condition ::= "Condition" name[] ("receiving" (parameter))?
	"{" 
	  ("stateAssessmentProcess" (stateAssessmentProcess))?  
	  (stateConstraints)* 
	"}";
	
	InverseCondition ::= "InverseCondition" name[] "inverseOf" operand[];
	AndCondition ::= "AndCondition" name[] "=" leftOperand[] "AND" rightOperand[];
	OrCondition ::= "OrCondition" name[] "=" leftOperand[] "OR" rightOperand[];
	XorCondition ::= "XorCondition" name[] "=" leftOperand[] "XOR" rightOperand[];
	
	RangeMultiplicity ::= "from" minOccurs[] "to" maxOccurs[];
	Many ::= "many";

	BasicDataType ::= "BasicDataType" name[]	  
	  ("(" (constraints)*")")? ("(" (annotations)*")")?;  
	
	DataStructure ::= "DataStructure" name[] ("is" superType[])? "{"
	  ("abstract" "=" abstract[])?
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";

	Variable ::= "Variable" name[] "ofType" type[];

	Constant ::= "Constant" value['"','"'];

	VariableReference ::= "ValueOf" variable[];
	  
	Exception ::= "Exception" name[] ("is" superType[])? "{" 
	  ("has" features)* 
	  ("(" (annotations)*")")?"}";
	
	Attribute ::= (multiplicityConstraint)? "attribute" name[] "ofType" type[];
	Association ::= (multiplicityConstraint)? "association"  name[] "identifying" relatedType[]; 
	Aggregation ::= (multiplicityConstraint)? "aggregate" (multiplicityConstraint)? name[] "ofType" relatedType[]; 
	Composition ::= (multiplicityConstraint)? "component" (multiplicityConstraint)? name[] "ofType" relatedType[];
	 
	QualityRequirement ::= "QualityRequirement" name[] (constraintExpression)? 
		"requiredBy" "("(requiredBy[])*")"
	  ("(" (annotations)*")")?;

	ConditionReference ::= "condition" condition[] 
		("with" (parameter) ("constructedUsing" (constructConditionParameterProcess))?)?; 
	
	ResultConstraint ::= "ResultConstraint" constraintExpression;
	  
	PreCondition ::= "PreCondition" name[]
	  "requiredBy" "("(requiredBy[])*")" 
      "raises" exception[] 
	  ("checks" conditionReference)? 
	  ("(" (annotations)*")")?;
	  
	PostCondition ::= "PostCondition" name[] 
		"requiredBy" "("(requiredBy[])*")"
	  ("ensures" functionalConstraint)? 
	  ("(" (annotations)*")")?;
 		
	ServiceRequirement ::= "use" requiredService[]
	 	"toAddress" "("(usedToAddress[])*")"
		("if" (condition))? ("(" (annotations)*")")?;
	
	ServiceContract ::= "ServiceContract" name[] "{"
	 (functionalRequirements)?
	 (qualityRequirements)*
	 ("undoneUsing" inverseService[])?
	 "Request" request   
	 "Result" result 
	  ("(" (annotations)*")")?"}";
	  
	Service ::= "Service" name[] "realizes" realizedContract[] "receiving" (requestVariable)
	"{"
		(serviceRequirements)*
		(activity)
	"}";  
	
	ActivitySequence ::= "doSequential" (name[])? "{" (activities)* "}"; 

	If ::= "if" (constraint) (activity);

	Choice ::= "choice" "{" (conditionalActivities)* ("else" (elseActivity)?) "}";
	
	ConcurrentActivity ::= "doConcurrent" (activity) ("blocking" "=" blocking[])?;
	
	Concurrency ::= "Concurrency" "{" (concurrentActivities)* "}"; 
	
	Wait ::= "wait" "until" (until);
	
	Create ::= "create" (producedVariable);
	
	Assign ::= "set" target "equalTo" source;
	Add ::= "add" source "to" target;
	Remove ::= "remove" target;
	
	RequestService ::= "requestService" requestedService[] "with" requestVariable[] 
			("yielding" (producedVariable))? 
		("{" 
			(exceptionHandlers)*
		"}")?;

	ExceptionHandler ::= "on" exception[] (activity);
		
	RaiseException ::= "raiseException" exception[] ("with" exceptionVariable[])?;	
		
	ReturnResult ::= "returnResult"	resultVariable[];
		
	While ::= "while" (condition) "do" (activity);	
		
	ForAll ::= "forAll" (query) "do" (activity); 	

	Annotation ::= "Note" language[] ":" content['"','"'];
}