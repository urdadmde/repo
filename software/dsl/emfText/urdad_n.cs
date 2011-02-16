SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>
START Model

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


TOKENSTYLES {
	"model" COLOR #7F0055, BOLD;
	"responsibilityDomain" COLOR #7F0055, BOLD;
	"dataTypes" COLOR #7F0055, BOLD;
	"services" COLOR #7F0055, BOLD;
	"functionalConstraints" COLOR #7F0055, BOLD;
	"qualityRequirements" COLOR #7F0055, BOLD;
	"language" COLOR #7F0055, BOLD;
	"expression" COLOR #7F0055, BOLD;
	"constraintExpression" COLOR #7F0055, BOLD;
	"rangeConstraint" COLOR #7F0055, BOLD;
	"datatype" COLOR #7F0055, BOLD;
	"dataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"exception" COLOR #7F0055, BOLD;
	"attribute" COLOR #7F0055, BOLD;
	"association" COLOR #7F0055, BOLD;
	"aggregation" COLOR #7F0055, BOLD;
	"composition" COLOR #7F0055, BOLD;
	"qualityRequirement" COLOR #7F0055, BOLD;
	"requiredBy" COLOR #7F0055, BOLD;
	"requirementExpression" COLOR #7F0055, BOLD;
	"functionalRequirement" COLOR #7F0055, BOLD;
	"functionalConstraint" COLOR #7F0055, BOLD;
	"preCondition" COLOR #7F0055, BOLD;
	"requiredService" COLOR #7F0055, BOLD;
	"postCondition" COLOR #7F0055, BOLD;
	"inverseService" COLOR #7F0055, BOLD;
	"service" COLOR #7F0055, BOLD;
	"request" COLOR #7F0055, BOLD;
	"result" COLOR #7F0055, BOLD;
	"process" COLOR #7F0055, BOLD;
	"activitySequence" COLOR #7F0055, BOLD;
	"background" COLOR #7F0055, BOLD;
	"concurrentActivities" COLOR #7F0055, BOLD;
	"switch" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"condition" COLOR #7F0055, BOLD;
	"activity" COLOR #7F0055, BOLD;
	"conditionalActivity" COLOR #7F0055, BOLD;
	"preConditionActivity" COLOR #7F0055, BOLD;
	"requestContraint" COLOR #7F0055, BOLD;
	"exceptionContraint" COLOR #7F0055, BOLD;
	"postConditionActivity" COLOR #7F0055, BOLD;
	"inverseRequestContraint" COLOR #7F0055, BOLD;
	"prePostConditionActivity" COLOR #7F0055, BOLD;
	"returnResultActivity" COLOR #7F0055, BOLD;
	"resultContraint" COLOR #7F0055, BOLD;
	"Services" COLOR #7F0055, BOLD;
	"concurrentActivity" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"Annotation" COLOR #7F0055, BOLD;
	"constraints" COLOR #7F0055, BOLD;
	"annotations" COLOR #7F0055, BOLD;
	"content" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "model" name[]  !0
	 (responsibilityDomains)*;
	 
	ResponsibilityDomain ::= "responsibilityDomain" name[] "{" !1
		("Data types" ":" (dataTypes)* )? "." !1
		("Functional constraints" ":" !2 
		  (functionalConstraints)*  )? !1
		("Quality constraints" ":" !2 
		  (qualityConstraints)* )? !1
		("Services" ":" !2 
		  (services)* )? !1
		("Responsibility domains" ":" !2 
		  (services)* )? !1
	  	("(" (annotations)*")")?
	"}" !0;

	Expression ::= "(" language [] ":" expressionString['"','"'] ")";
	
	GeneralConstraint ::= "Constraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;
	
	BooleanExpression ::=  language [] ":" expressionString['[',']'];

	RangeMultiplicity ::= "["minOccurs[] "," maxOccurs[] "]" ";";
	BasicDataType ::= "Basic data type" name[]	  
	  ("(" (annotations)*")")?;
	
	DataStructure ::= "Data structure" name[] ("is" superType[])? !1 
	  (attributes)* !1 (associations)* 
	  ("(" (annotations)*")")?;
	Exception ::= "exception" name[] ("is" superType[])? !1 
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?;
	
	
	Attribute ::= "-" "has attribute" name[] "of type" type[];
	Association ::= "-" "is associated with" name[] "of type" relatedType[] (multiplicityConstraint)?; 
	Aggregation ::= "-" "has" name[] "of type" relatedType[] (multiplicityConstraint)?; 
	Composition ::= "-" "contains" name[] "of type" relatedType[] (multiplicityConstraint)?;
	 
	QualityRequirement ::= name[]   
		"is required by" requiredBy[]
		qualityConstraint[] "."
	  ("(" (annotations)*")")?;
	  
	QualityConstraint ::= name[] ":" (qualityExpression);	  
		
	FunctionalRequirement ::= name[]  
		" is required by" requiredBy[] 
	 	functionalConstraint[]  "."
	  ("(" (annotations)*")")?;
	
	PreCondition ::= "preCondition" name[]
		("requires" requiredService[])?
		 "raises" exception[]
		("when" condition)?
	  ("(" (annotations)*")")?;

	PostCondition ::= "postCondition" name[]
		("requires" requiredService[])?
		("undone by" inverseService[] ";" )? 
	  ("(" (annotations)*")")?;
	
	Service ::= "service" name[] !1
	 "Functional requirements:" !2
	 (functionalRequirements )+ !1
	 "Quality requirements:" !2
	 (qualityRequirements )* !1
	 "Request structure:" !2
	 "request" request !1  
	 "Result structure:" !2
	 "result" result  !1
	 (process)? !0
	  ("(" (annotations)*")")?;
	 
	Process ::= "process" processActivity ("(" (annotations)*")")?;

	ActivitySequence ::= "activitySequence" "{" (activities)* "}";
	ConcurrentActivities ::= "concurrentActivities" "{" (activities)* "}";
	ConcurrentActivity ::= "concurrentActivity" ("(" "blocking" "=" blocking[]")")?
		activity
		".";
	Switch ::= "Branching:" "{" (conditionalActivities)* "}";
	
	While ::= "while" condition  activity ".";
		
	ConditionalActivity ::= "if" condition "then" activity ";";
	
	PreConditionActivity ::= "check" preCondition[]  
		("Request constraints:" (requestContraints)*)? 
		("Exception constraints:" (exceptionContraints)*)? 
		("(" (annotations)*")")?;
		
	
	PostConditionActivity ::= "do"  postCondition[]  
		("Request constraints:" (requestContraints)*)? 
		("Undo request constraints:" (inverseRequestContraints)*)? 
		("(" (annotations)*")")?;
	
	PrePostConditionActivity ::=  
		"emsure" preCondition[] ";" 
		"do" postCondition[] ";" 
		("Request constraints:" (requestContraints)*)? 
		("Exception constraints:" (exceptionContraints)*)? 
		("Undo request constraints:" (inverseRequestContraints)*)? 
		("(" (annotations)*")")?;

	ReturnResultActivity ::= "return result"   
		("Result constraints:" (resultContraints)*)? 
		("(" (annotations)*")")?;
		
	Annotation ::= "Note" language[] ":" content['"','"']".";
	
}