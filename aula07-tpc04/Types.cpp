//#include <stdafx.h>
#include <stdio.h> 

using namespace System;

/*
* a value type
*/
value struct V {
private:
	int x;
public:
	V(int x){
		this->x = x;
	}
	int Print() {
		return printf("V=%d\n", x);
	}

	void Address(){
		printf("address of field x: %p\n", &x);
	}
};

/*
 * unmanaged pointer
 */
void AddressOfU(void* o){
	printf("address of o: %p\n", o);
};

/*
 * reference to the managed heap
 */
void AddressOfM(Object^ o){ 
	IntPtr* p = (IntPtr*)&o;
	printf("address of o: %p\n", *p);
};

void main() {
	V p1 = V(5); 
	AddressOfU(&p1);
	p1.Address();

	V^ p2 = p1;
	AddressOfM(p2);
	p2->Address();

};